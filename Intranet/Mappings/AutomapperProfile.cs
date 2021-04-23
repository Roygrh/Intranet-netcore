using AutoMapper;
using Intranet.Models;
using Intranet.Models.Sicon;
using Intranet.Services.DateTimeManagement;
using Intranet.Services.FileConverter;
using Intranet.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            var dateTimeManagement = new DataTimeManagement();
            PersonalVM user = new PersonalVM();
            user.cod_personal = "PES-001234";
            user.nombre = "Mario Huapaya Chumpitaz";

            //Convert from entity VM to entity data
            CreateMap<AuthorizationVM, IT_AUTORIZACION>()
                .ForMember(entity => entity.FECHA_SALIDA_PROG, entityVM => entityVM.MapFrom(e => dateTimeManagement.StringToDateTime(e.FECHA_SALIDA_PROG + " " + e.HORA_SALIDA_PROG)))
                .ForMember(entity => entity.FECHA_RETORNO_PROG, entityVM => entityVM.MapFrom(e => dateTimeManagement.StringToDateTime(e.FECHA_RETORNO_PROG + " " + e.HORA_RETORNO_PROG)))
                .ForMember(entity => entity.FILE, entityVM => entityVM.MapFrom(e => new FileConverter().ConvertFileToBytes(e.FILE)))
                .ForMember(entity => entity.NOMBRE_ARCHIVO, entityVM => entityVM.MapFrom(e => e.FILE.FileName.Split("\\".ToCharArray()).Last()))
                .ForMember(entity => entity.TIPO_CONTENIDO_FILE, entityVM => entityVM.MapFrom(e => e.FILE.ContentType)); ;
            CreateMap<AuthorizationStateVM, IT_ESTADO_AUTORIZACION>();
            CreateMap<AuthorizationMovementVM, IT_AUTORIZACION_MOVIMIENTOS>();
            CreateMap<PersonalVM, ca_personal>();
            CreateMap<AttendanceVM, intranet_asistencia>();
            CreateMap<VacationVM, intranet_vacaciones>();

            //Convert from entity data to entidad VM
            CreateMap<IT_AUTORIZACION, AuthorizationVM>()
                .ForMember(entityVM => entityVM.FECHA_SALIDA_PROG_DATE_TIME, entity => entity.MapFrom(e => e.FECHA_SALIDA_PROG))
                .ForMember(entityVM => entityVM.FECHA_RETORNO_PROG_DATE_TIME, entity => entity.MapFrom(e => e.FECHA_RETORNO_PROG))
                .ForMember(entityVM => entityVM.FILE, entity => entity.MapFrom(e => new FileConverter().ConvertBytesToFile(e.FILE, e.TIPO_CONTENIDO_FILE, e.NOMBRE_ARCHIVO)))
                .ForMember(entityVM => entityVM.FECHA_SALIDA_PROG, entity => entity.MapFrom(e => DataTimeManagement.DateToString(e.FECHA_SALIDA_PROG)))
                .ForMember(entityVM => entityVM.FECHA_RETORNO_PROG, entity => entity.MapFrom(e => DataTimeManagement.DateToString(e.FECHA_RETORNO_PROG)))
                .ForMember(entityVM => entityVM.HORA_SALIDA_PROG, entity => entity.MapFrom(e => DataTimeManagement.TimeToString(e.FECHA_SALIDA_PROG)))
                .ForMember(entityVM => entityVM.HORA_RETORNO_PROG, entity => entity.MapFrom(e => DataTimeManagement.TimeToString(e.FECHA_RETORNO_PROG)))
                .ForMember(entityVM => entityVM.AUTHORIZINGUSER, entity => entity.MapFrom(e => user));
            CreateMap<IT_ESTADO_AUTORIZACION, AuthorizationStateVM>();
            CreateMap<IT_AUTORIZACION_MOVIMIENTOS, AuthorizationMovementVM>();
            CreateMap<ca_personal, PersonalVM>();
            CreateMap<intranet_asistencia, AttendanceVM>();
            CreateMap<intranet_vacaciones, VacationVM>();

            //Converts for reasons of comfort
            Nullable<System.DateTime> date = null;
            CreateMap<IT_AUTORIZACION, IT_AUTORIZACION_MOVIMIENTOS>()
            .ForMember(Autho => Autho.ID_AUTORIZACION, Autho => Autho.MapFrom(a => a.AUTORIZACION_ID))
            .ForMember(AuthoMove => AuthoMove.ID_USUARIO_AUTORIZA, Autho => Autho.MapFrom(a => a.USUARIO_AUTORIZA))
            .ForMember(AuthoMove => AuthoMove.USUARIO_CREA, Autho => Autho.MapFrom(a => string.Empty))
            .ForMember(AuthoMove => AuthoMove.FECHA_CREACION, Autho => Autho.MapFrom(a => DateTime.Now))
            .ForMember(AuthoMove => AuthoMove.FECHA_EDICION, Autho => Autho.MapFrom(a => date))
            .ForMember(AuthoMove => AuthoMove.USUARIO_EDITA, Autho => Autho.MapFrom(a => string.Empty));
            CreateMap<IT_CONTENIDO_GENERAL, IT_CONTENIDO_GENERAL_AUDITORIA>();
            CreateMap<IT_AUTORIZACION, IT_AUTORIZACION_AUDITORIA>();
        }
    }
}
