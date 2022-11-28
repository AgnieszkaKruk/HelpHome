using Data.Services;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [Route("api/Offerents/{offerentId}/cleaningpreferences")]
    [ApiController]
    public class CleaningPreferenceController : ControllerBase
    {
        private readonly ICleaningPreferencesServices _cleaningPreferenceServices;

        public CleaningPreferenceController(ICleaningPreferencesServices cleaningPrefServices)
        {
            _cleaningPreferenceServices = cleaningPrefServices;

        }
    }
}
