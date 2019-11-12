using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Services
{
    public class ImagemService : BaseService<Imagem>, IImagemService
    {
        private readonly IImagemRepository _imagemRepository;
        public ImagemService(IImagemRepository imagemRepository) : base(imagemRepository)
        {
            _imagemRepository = imagemRepository;
        }
    }
}
