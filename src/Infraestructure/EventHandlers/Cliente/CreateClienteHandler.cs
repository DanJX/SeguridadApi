using ApplicationCore.Wrappers;
using Infraestructure.Persistence;
using AutoMapper;
using MediatR;
using ApplicationCore.Commands;

namespace Infraestructure.EnventHandlers.Cliente
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteCommand ,Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateClienteHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Response<int>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var u               = new CreateClienteCommand();
            u.nombre            = request.nombre;
            u.apellidoPaterno   = request.apellidoPaterno;


            var us = _mapper.Map<Domain.Entities.cliente>(u);
            await _context.clientes.AddAsync(us);
            await _context.SaveChangesAsync();
            return new Response<int>(us.id, "Registro Creado");

        }
    }
}