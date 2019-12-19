using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface ICamerasDal : IEntityRepository<Cameras>
    {
        List<CamerasComplex> GetComplexCameras(Expression<Func<CamerasComplex, bool>> filter = null);
    }
}
