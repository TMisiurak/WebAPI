using System;
using AutoMapper;
using DAL.AutoMapper.Profiles;

namespace DAL.AutoMapper
{
    public class AutoMapperConfig
    {
        static IMapper _instance;

        public static IMapper Instance
        {
            get
            {
                if (_instance == null)
                    CreateAutoMapper();
                return _instance;
            }
        }

        public static void CreateAutoMapper()
        {
            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<EmployeeProfile>();
            });

            _instance = autoMapperConfig.CreateMapper();
        }
    }
}
