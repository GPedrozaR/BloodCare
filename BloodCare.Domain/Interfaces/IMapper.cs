namespace BloodCare.Domain.Interfaces
{
    public interface IMapper<TDomain, TInfrastructure>
    {
        TInfrastructure ToInfrastructure(TDomain entity);
        TDomain ToDomain(TInfrastructure entity);
    }
}
