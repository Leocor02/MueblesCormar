using System;
using System.Collections.Generic;
using System.Text;

namespace MueblesCormar.Services
{
    public static class CnnToAPI
    {
        //Aquí se definen las rutas de consumo del API
        //Además se define la info de Api key necesaria para consumir los controladores

        public static string ProductionURL = "http://192.168.0.3:45455/api/";
        public static string TestingRoute = "http://192.168.0.3:45455/api/";

        public static string ApiKeyName = "MCApiKey";
        public static string ApiKeyValue = "MCinventario123";

    }
}
