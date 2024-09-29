using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Http;

namespace EndocPM.WebAPI
{
    public class UserDataMap : IEntityTypeConfiguration<UserData>
    {
        public readonly IHttpContextAccessor _iHttpContextAccessor;        

        public UserDataMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }        

        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            string schemaName = this._iHttpContextAccessor.HttpContext.Request.Headers["Schema"];
        }



    }
}
