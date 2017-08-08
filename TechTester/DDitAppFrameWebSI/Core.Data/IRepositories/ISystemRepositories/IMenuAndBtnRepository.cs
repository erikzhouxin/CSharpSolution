﻿using DDit.Core.Data.SystemEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDit.Core.Data.IRepositories
{
  public interface IMenuAndBtnRepository
    {
      void MenuMapBtn(int MenuID, List<MenuMappingButton> mplist);

      List<MenuMappingButton> GetMBList(MenuMappingButton model);
    }
}
