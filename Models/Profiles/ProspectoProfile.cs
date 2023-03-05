using AutoMapper;
using Backend_ASP.NETcore.Models.DTO;

namespace Backend_ASP.NETcore.Models.ProspectoProfile
{
    public class ProspectoProfile: Profile
    {
        public ProspectoProfile()
        {
            CreateMap<Prospecto, ProspectoDTO>();
            CreateMap<ProspectoDTO, Prospecto>();
        }
    }
}
