﻿using BusinessLayer.Domain.Store.Shirts;
using Contracts.DTOs.StoreItems.Shirts;
using Contracts.Enums.Store;

using BusinessLayer.Helper;

namespace BusinessLayer.Mapper.ApiMapper.StoreItems.TShirts
{
    public static class TShirtApiMapper
    {
        public static TShirtDetailsDto ToDetailsDto(TShirt model)
        {
            return new TShirtDetailsDto
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Category = model.Category.ToString(),
                InStock = model.InStock,
                Material = model.Material,
                Gender = model.Gender.ToString(),
                Variants = model.Variants.Select(v => new TShirtVariantDto
                {
                    TShirtModelId = v.TShirtModelId,
                    VariantId = v.VariantId,
                    Color = v.Color,
                    Size = v.Size.ToString(),
                    Quantity = v.Quantity,
                }).ToList()
            };
        }

        public static TShirt ToDetailsDomain(TShirtDetailsDto dto)
        {
            return new TShirt()
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                Category = EnumHelper.ParseEnum(dto.Category, StoreCategoryType.TShirts),
                InStock = dto.InStock,
                Material = dto.Material,
                Gender = EnumHelper.ParseEnum(dto.Gender, Genders.Unisex),
                Variants = dto.Variants.Select(v => new TShirtVariant()
                {
                    TShirtModelId = v.TShirtModelId,
                    VariantId = v.VariantId,
                    Color = v.Color,
                    Size = EnumHelper.ParseEnum(v.Size, Sizes.M),
                    Quantity = v.Quantity,
                }).ToList()
            };
        }
    }
}
