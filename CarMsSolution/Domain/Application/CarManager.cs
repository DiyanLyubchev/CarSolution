using Domain.Contracts;
using Domain.Model;
using StateMachineDataAccess.DbManager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Application
{
    public class CarManager : ICarManager
    {
        private ICarGasService gasService;
        private ICarDieselService dieselService;
        private IStateMachineDbManager stateMachine;
        private int machineId;
        public CarManager(IServiceFactory factory, IStateMachineDbManager stateMachine)
        {
            this.gasService = factory.GetCarGasService();
            this.dieselService = factory.GetCarDieselService();
            this.stateMachine = stateMachine;
        }

        public async Task<List<CarViewModel>> GetCarsAsync()
        {
            List<CarViewModel> allCars = new List<CarViewModel>();

            List<CarViewModel> gasCars = await gasService.GetGasCarAsync();
            List<CarViewModel> dieselCars = await dieselService.GetDieselCarAsync();

            allCars.AddRange(gasCars);

            allCars.AddRange(dieselCars);

            return allCars;
        }

        public async Task AddNewCarAsync(CarViewModel viewModel)
        {
            if (viewModel.EngineType == "Gas")
            {
                await this.gasService.AddNewCar(viewModel);
            }

            else if (viewModel.EngineType == "Diesel")
            {
                await this.dieselService.AddNewCar(viewModel);
            }

            else if (viewModel.EngineType == "DieselAndGas")
            {
                try
                {
                    var stateMachineId = await this.stateMachine.CreateStateMachineAsync();
                    machineId = stateMachineId;
                    var gasCarId = await this.gasService.AddNewCar(viewModel);
                    if (gasCarId == 0)
                    {
                        throw new ArgumentNullException("Id cannot be zoro");
                    }
                    await this.stateMachine.UpdateStateForGasCarAsync(stateMachineId, gasCarId);
                    var dieselCarID = await this.dieselService.AddNewCar(viewModel);
                    if (dieselCarID == 0)
                    {
                        throw new ArgumentNullException("Id cannot be zoro");
                    }
                    await this.stateMachine.UpdateStateForDieselCarAsync(stateMachineId, dieselCarID);
                    await this.stateMachine.UpdateStateSuccessAsync(stateMachineId);
                }
                catch (Exception)
                {
                    var currentState = await this.stateMachine.TakeCurrentStateAsync(machineId);

                    if (currentState.State == 'G')
                    {
                        await this.gasService.RemoveGasCarAsync(currentState.GasCarId);
                    }
                }
            }
        }
    }
}

