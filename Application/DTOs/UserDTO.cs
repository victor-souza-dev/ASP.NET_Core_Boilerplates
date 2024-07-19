using Application.Abstractions.Mapping;
using Application.Abstractions.Responses;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs;

public class UserDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}

public class UserResponseDTO: IUserResponse {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UserPaginationDTO<UserResponseDTO> : IGenericPaginationResponse<UserResponseDTO>, IMapFrom<User> {
    public List<UserResponseDTO> Items { get; set; } = new List<UserResponseDTO>();
    public int TotalCount { get; set; } = 0;
    public bool HasNext { get; set; } = false;

    public void Mapping(Profile profile) {
        profile.CreateMap<User, UserResponseDTO>();
        profile.CreateMap<IGenericPaginationResponse<User>, UserPaginationDTO<UserResponseDTO>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
    }
}
