using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public interface IReadFile
    {
        List<Reciepe> LoadEntries(string path);
    }
}
