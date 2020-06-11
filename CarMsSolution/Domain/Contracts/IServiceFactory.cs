namespace Domain.Contracts
{
    public interface IServiceFactory
    {
        ICarDieselService GetCarDieselService();

        ICarGasService GetCarGasService();
    }
}
