using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Listers_Candidate_Assessment.Startup))]
namespace Listers_Candidate_Assessment
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
