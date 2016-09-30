﻿using eh.attributes;
using eh.attributes.enums;
using System.Collections.Generic;
using TravelAgent.Model;

namespace TravelAgent.WebAPI.Models
{
    public class ReferencesDto
    {
        public int Id { get; set; }
        [Col("A")]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataValid(DataTypeEnum.STRING)]
        public string Name { get; set; }

        [Col("B")]
        [ColDataConstraint(ConstraintsEnum.NULL)]
        [ColDataValid(DataTypeEnum.STRING_N)]
        public string Tel { get; set; }

        [Col("C")]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataValid(DataTypeEnum.INT)]
        public int SchoolId { get; set; }

        public References ToModel()
        { 
            return new References{ Name=this.Name, Id=this.Id, SchoolId=this.SchoolId, Tel=this.Tel};
        }

        public static IList<References> ToList(IList<ReferencesDto> dto_list)
        { 
            IList<References> list = new List<References>();
            foreach (ReferencesDto item in dto_list)
            {
                list.Add(item.ToModel());
            }
            return list;
        }
    }
}