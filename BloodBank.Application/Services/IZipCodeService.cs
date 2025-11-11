using BloodBank.Application.Models;

namespace BloodBank.Application.Services
{
    public interface IZipCodeService
    {
        Task<ZipCodeResult> GetZipCode(string code);
    }
}
