using AssessmentApplication.Models;

namespace AssessmentApplication.Authentication
{
    public interface IAuthenticationManager
    {
        string Authenticate(UserAuth user);
    }
}
