﻿using AutoMapper;

namespace Application.Abstractions.Mapping {
    public interface IMapFrom<T> {

        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
