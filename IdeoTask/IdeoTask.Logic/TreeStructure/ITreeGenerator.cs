using IdeoTask.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeoTask.Logic.TreeStructure
{
    public interface ITreeGenerator
    {
        List<Branch> SortTree(SortType sortType, List<Branch> branches);
    }
}
