using SqlSugar;
using System.Collections.Generic;
using System.Threading.Tasks;
using VOL.Builder.IRepositories;
using VOL.Builder.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.DBManager;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;
using VOL.Entity.DomainModels.Sys;

namespace VOL.Builder.Services
{
    public partial class Sys_TableInfoService : ServiceBase<Sys_TableInfo, ISys_TableInfoRepository>, ISys_TableInfoService, IDependency
    {
        public  Sys_TableInfoService(ISys_TableInfoRepository repository)
             : base(repository) 
        { 
           Init(repository);   
        }
        public static ISys_TableInfoService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_TableInfoService>(); }
        }

        public List<DbColumnInfo> GetDbTableColumns(string tableName)
        {
            var colinfo =repository.DbContext.DbMaintenance.GetColumnInfosByTableName(tableName);
            return colinfo;            
        }
    }
}

