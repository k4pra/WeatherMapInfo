using OsmSharp.IO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMapInfo.Map
{
    public class OpenStreetMap
    {
        #region Property
        private ClientsFactory? clientFactory;
        private INonAuthClient? client;
        OsmSharp.Node? node;
        #endregion
        async Task<bool> InitMapAsync()
        {
            string strApiURL;

#if DEBUG
            strApiURL = "https://master.apis.dev.openstreetmap.org/api/";
#else
            strApiURL = "https://www.openstreetmap.org/api/";
#endif
            clientFactory = new ClientsFactory(null, new HttpClient(), strApiURL);
            client = clientFactory.CreateNonAuthClient();
            node = await client.GetNode(100);

            if (clientFactory == null)
                return false;
            return true;
        }

        string GetAPIVersion()
        {
            if (client == null)
                return string.Empty;
            string strVersion = string.Empty;
            var version = client.GetVersions();

            strVersion = version.ToString();

            return strVersion;
        }
    }
}
