using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLearning.Rendering.DashboardRenderers
{
    public interface IBookCoverRenderer
    {

        byte[] RenderCover(string coverPatn, byte[] templateBytes, BookCoverRendererOptions options);

    }
}