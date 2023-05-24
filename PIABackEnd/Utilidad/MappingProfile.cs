using PIABackEnd.DTOs;
using PIABackEnd.Entidades;
using AutoMapper;

namespace PIABackEnd.Utilidad
{
    public class MappingProfile
    {
        public class MappingPro : Profile
        {
            public MappingPro()
            {
                CreateMap<Paciente, PacienteDTO>();
                CreateMap<CrearPacienteDTO, Paciente>();
                CreateMap<PacientePatchDTO, Paciente>();
                CreateMap<Paciente,PacientePatchDTO >();
                CreateMap<Doctor, DoctorDTO>();
                CreateMap<DoctorDTO, Doctor>();
                CreateMap<CrearCitaDTO, Cita>();
                CreateMap<CitaDTO, Cita>();
                CreateMap<Cita, CitaDTO>();

            }
        }
    }
}
