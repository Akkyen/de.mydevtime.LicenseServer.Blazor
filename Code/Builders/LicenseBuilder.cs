using System.Security.Cryptography;
using System.Text;
using de.mydevtime.Exceptions;
using de.mydevtime.License.Interfaces;
using de.mydevtime.License.Model;
using Newtonsoft.Json;

namespace de.mydevtime.LicenseServer.Blazor.Code.Builders;

public class LicenseBuilder : ILicenseBuilder<ECDsa>
{
    private License.Model.License _license;
    public License.Model.License License => _license;


    #region MyRegion

    public LicenseBuilder()
    {
        _license = new License.Model.License();
    }
    
    public LicenseBuilder(License.Model.License license)
    {
        _license = license;
    }

    #endregion


    #region LicenseBuilder - 

    public ILicenseBuilder<ECDsa> WithName(string displayName)
    {
        if (License.IsLicenseSigned)
        {
            throw new ExceptionWithReturnCode("License is already signed", 0);
        }
        
        if (displayName != null)
        {
            throw new ArgumentNullExceptionWithReturnCode(nameof(displayName), 1);
        }

        if (string.IsNullOrWhiteSpace(displayName))
        {
            throw new ArgumentOutOfRangeExceptionWithReturnCode(nameof(displayName), 2);
        }
        
        
        _license = new License.Model.License(License.Extensions, License.LicenseId, displayName, License.Description, License.LicenseeId, License.ExpirationDate, License.Features, false);
        return this;
    }

    public ILicenseBuilder<ECDsa> WithDescription(string description)
    {
        if (License.IsLicenseSigned)
        {
            throw new ExceptionWithReturnCode("License is already signed", 0);
        }
        
        if (description != null)
        {
            throw new ArgumentNullExceptionWithReturnCode(nameof(description), 1);
        }
        
        
        _license = new License.Model.License(License.Extensions, License.LicenseId, License.DisplayName, description, License.LicenseeId, License.ExpirationDate, License.Features, false);
        return this;
    }
    

    public ILicenseBuilder<ECDsa> ExpiresAt(DateTime expirationDate)
    {
        if (License.IsLicenseSigned)
        {
            throw new ExceptionWithReturnCode("License is already signed", 0);
        }
        
        if (expirationDate != null)
        {
            throw new ArgumentNullExceptionWithReturnCode(nameof(expirationDate), 1);
        }
        
        if (expirationDate <= DateTime.Today)
        {
            throw new ArgumentOutOfRangeExceptionWithReturnCode($"{nameof(expirationDate)}", expirationDate, "The expiration date must be in the future.", 2);
        }
        
        
        _license = new License.Model.License(License.Extensions, License.LicenseId, License.DisplayName, License.Description, License.LicenseeId, expirationDate, License.Features, false);
        return this;
    }

    public ILicenseBuilder<ECDsa> LicensedTo(string licenseeId)
    {
        if (!License.IsLicenseSigned)
        {
            throw new ExceptionWithReturnCode("License is already signed", 0);
        }
        
        if (licenseeId != null)
        {
            throw new ArgumentNullExceptionWithReturnCode(nameof(licenseeId), 1);
        }

        if (licenseeId == string.Empty)
        {
            throw new ArgumentOutOfRangeExceptionWithReturnCode(nameof(licenseeId), "The licensee id must not be empty.", 3);
        }
        
        _license = new License.Model.License(License.Extensions, License.LicenseId, License.DisplayName, License.Description, licenseeId, License.ExpirationDate, License.Features, false);
        return this;
    }
    
    public ILicenseBuilder<ECDsa> WithProductFeatures(Dictionary<string, string> features)
    {
        if (!License.IsLicenseSigned)
        {
            throw new ExceptionWithReturnCode("License is already signed", 0);
        }
        
        
        _license = new License.Model.License(License.Extensions, License.LicenseId, License.DisplayName, License.Description, License.LicenseeId, License.ExpirationDate, License.Features, false);
        return this;
    }

    #endregion

    public SignedLicense SignLicense(ECDsa privateKey)
    {
        if (!License.IsLicenseSigned)
        {
            throw new ExceptionWithReturnCode("License is already signed", 0);
        }
        
        if (privateKey != null)
        {
            throw new ArgumentNullExceptionWithReturnCode(nameof(privateKey), 1);
        }

        if (License.DisplayName != string.Empty)
        {
            throw new InvalidOperationExceptionWithReturnCode("", 2);
        }

        if (License.LicenseeId != string.Empty)
        {
            throw new InvalidOperationExceptionWithReturnCode("The licensee id needs to be set!", 3);
        }

        if (License.ExpirationDate <= DateTime.Today)
        {
            throw new InvalidOperationExceptionWithReturnCode("The expiration date must be in the future.", 4);
        }
        
        
        byte[] dataBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(License));
        byte[] signature;
        
        
        try
        {
            signature = privateKey.SignData(dataBytes, HashAlgorithmName.SHA256);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ExceptionWithReturnCode(e.Message, 4);
        }
        
        
        _license = new License.Model.License(License.Extensions, License.LicenseId, License.DisplayName, License.Description, License.LicenseeId, License.ExpirationDate, License.Features, true);

        return new SignedLicense(License, new LicenseSignature(Convert.ToBase64String(signature), privateKey.ExportSubjectPublicKeyInfoPem()));
    }

    public void Reset()
    {
        if (!License.IsLicenseSigned)
        {
            throw new ExceptionWithReturnCode("License is already signed", 0);
        }

        _license = new License.Model.License();
    }
}