using AutoMapper;
using Intranet.Models;
using Intranet.ViewModels;
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
            //Convert from entity VM to entity data
            CreateMap<AuthorizationVM, IT_AUTORIZACION>();
            CreateMap<AuthorizationStateVM, IT_ESTADO_AUTORIZACION>();
            CreateMap<AuthorizationMotiveVM, IT_MOTIVO_AUTORIZACION>();
            CreateMap<AuthorizationMovementVM, IT_AUTORIZACION_MOVIMIENTOS>();

            //Convert from entity data to entidad VM
            CreateMap<IT_AUTORIZACION, AuthorizationVM>();
            CreateMap<IT_ESTADO_AUTORIZACION, AuthorizationStateVM>();
            CreateMap<IT_MOTIVO_AUTORIZACION, AuthorizationMotiveVM>();
            CreateMap<IT_AUTORIZACION_MOVIMIENTOS, AuthorizationMovementVM>();

            //Converts for reasons of comfort
            CreateMap<IT_AUTORIZACION, IT_AUTORIZACION_MOVIMIENTOS>();
            CreateMap<IT_CONTENIDO_GENERAL, IT_CONTENIDO_GENERAL_AUDITORIA>();
            CreateMap<IT_AUTORIZACION, IT_AUTORIZACION_AUDITORIA>();
        }
    }
}
