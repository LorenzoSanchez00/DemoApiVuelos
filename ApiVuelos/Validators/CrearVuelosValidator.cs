using ApiVuelos.DTOs;
using FluentValidation;

namespace ApiVuelos.Validators
{
    public class CrearVuelosValidator : AbstractValidator<CrearVueloDto>
    {
        public CrearVuelosValidator()
        {
            RuleFor(x => x.IdAerolinea).NotEmpty().WithMessage("El ID de la aerolinea es obligatorio")
                .InclusiveBetween(1, 2).WithMessage("El ID de la aerolinea debe estar entre 1 y 2").NotNull();

            RuleFor(x => x.Origen).NotEmpty().WithMessage("Error, debe ingresar un Origen")
                .Length(4,35).WithMessage("El Origen debe tener entre 4 y 35 caracteres");

            RuleFor(x => x.Destino).NotEmpty().WithMessage("Error, debe ingresar un Destino")
                .Length(4, 35).WithMessage("El Destino debe tener entre 4 y 35 caracteres");

            RuleFor(x => x.FechaIda).NotEmpty().WithMessage("Error, debe ingresar una Fecha de Partida").NotNull();

            RuleFor(x => x.FechaVuelta).NotEmpty().WithMessage("Error, debe ingresar una Fecha de Vuelta").NotNull();

            RuleFor(x => x.Clase).NotEmpty().WithMessage("Error, debe ingresar una Clase")
                .Length(4, 20).WithMessage("El origen debe tener entre 4 y 20 caracteres");

            RuleFor(x => x.Precio).NotEmpty().WithMessage("Error, debe ingresar el Precio del Vuelo")
                .GreaterThan(10).WithMessage("El valor minimo admitido es 10")
                .Must(NotLetter).WithMessage("El precio solo debe poseer numeros");

        }


        private bool NotLetter(decimal var)
        {
            string x = var.ToString();
            return !x.Any(char.IsAsciiLetter) && !x.Any(char.IsSymbol) || x.Contains(".");
        }
    }
}
