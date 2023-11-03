using DataManager.Model;
using System;
using System.ComponentModel.Design;
using System.Data;
using System.Xml.Linq;

namespace DataManger
{
    public class DataRepository : IDataRepository
    {
        List<Company> _companyList = new List<Company>()
        {
            new Company(){ Name = "Company1", Address1 = "Add1", Id = 1, Active = true },
            new Company() { Name = "Company2", Address1 = "Add2", Id = 2, Active = true }
        };

        List<Claim> _claimsList = new List<Claim>()
        {
            new Claim { UCR = "UCR1", AssuredName = "AssuredName1", CompanyId = 1, ClaimDate = new DateTime(2023, 09, 25) },
            new Claim { UCR = "UCR2", AssuredName = "AssuredName2", CompanyId = 2, ClaimDate = new DateTime(2023, 10, 25) }
        };

        List<Claimstype> _claimstype = new List<Claimstype>() { new Claimstype { Id = 1, Name = "Commercial" } };

        public DataRepository()
        {
        }

        public Company CompanyData(string Name)
        {
            return _companyList.FirstOrDefault(x => x.Name == Name);
        }

        //returns a list of string UCR for claims of a company
        public List<string> CompanyClaims(int CompanyId)
        {
            return _claimsList.Where(x => x.CompanyId == CompanyId).Select(y => y.UCR).ToList();
        }

        public DataManager.Model.Claim CompanyClaimsDetails(string UCR)
        {
            DataManager.Model.Claim claim = _claimsList.Where(x => x.UCR == UCR).FirstOrDefault();

            claim.AgeInDays = (DateTime.Now - claim.ClaimDate).Days;

            return claim;
        }

        public bool UpdateCompanyClaimsDetails(Claim claim)
        {
            bool retval = false;
            int index = _claimsList.IndexOf(_claimsList.Where(x => x.UCR == claim.UCR).FirstOrDefault());

            if (index >= 0)
            {
                _claimsList[index] = claim;
                retval = true;
            }

            return retval;
        }

    }
}