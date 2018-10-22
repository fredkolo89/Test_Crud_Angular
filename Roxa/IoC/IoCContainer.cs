using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.IoC
{
    //inny sposob dobrania sie do contextu
    //public static class IoC
    //{
    //    public static ApplicationDbContext GetApplicationDbContext() => IoCContainer.Provider.GetService<ApplicationDbContext>();
    //}

    public static class IoCContainer
    {
        //public static ServiceProvider Provider { get; set; }

        public static IConfiguration Configuration { get; set; }
    }
}
