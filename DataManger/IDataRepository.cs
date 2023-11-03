using DataManager.Model;

namespace DataManger
{
    public interface IDataRepository
    {
        Company CompanyData(string Name);
        List<string> CompanyClaims(int CompanyId);
        Claim CompanyClaimsDetails(string UCR);
        bool UpdateCompanyClaimsDetails(Claim claim);
    }
}