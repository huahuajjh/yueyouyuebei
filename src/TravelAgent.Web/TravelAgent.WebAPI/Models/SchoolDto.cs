﻿using eh.attributes;
using eh.attributes.enums;
using System.Collections.Generic;
using TravelAgent.Model;

namespace TravelAgent.WebAPI.Models
{
    public class SchoolDto
    {
        public int Id { get; set; }
                
        [Col("A")]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataValid(DataTypeEnum.STRING)]
        public string Name { get; set; }

        [Col("B")]
        [ColDataConstraint(ConstraintsEnum.NULL)]
        [ColDataValid(DataTypeEnum.STRING_N)]
        public string ShortName { get; set; }

        [Col("C")]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataValid(DataTypeEnum.INT)]
        public int AreaId { get; set; }

        public School ToModel()
        { 
            return new School{ ShortName=this.ShortName, Name=this.Name, Id=this.Id, AreaId=this.AreaId};
        }

        public static IList<School> ToList(IList<SchoolDto> dto_list)
        {
            IList<School> list = new List<School>();
            foreach (SchoolDto item in dto_list)
            {
                list.Add(item.ToModel());
            }
            return list;
        }
    }
}