using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_29_07_Mine.Services
{
    public class SkinService
    {
        public string GetAvatar(string uuid)
        {
            return $"https://crafatar.com/avatars/{uuid}?size=256";
        }

        public string GetSkin(string uuid)
        {
            return $"https://crafatar.com/skins/{uuid}";
        }

        public string GetBody(string uuid)
        {
            return $"https://crafatar.com/renders/body/{uuid}?size=8";
        }

        public string GetHead(string uuid)
        {
            return $"https://crafatar.com/renders/head/{uuid}?size=256";
        }
    }
}