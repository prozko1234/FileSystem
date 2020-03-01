using IdeoTask.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeoTask.Logic.TreeStructure
{
    public interface ITreeGenerator
    {
        List<CatalogBranchDTO> GetTreeS();
    }
}
