using FluentValidation;
using Shared.DTOs.Appointment;

namespace BusinessLogicLayer.Validators;

public class CreateAppointmentValidator : AbstractValidator<CreateAppointmentDto>
{
    public CreateAppointmentValidator()
    {
            
        RuleFor(x => x.AppointmentDate)
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Appointment date must be in the future.");

   
        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Status is required.")
            .IsInEnum()
            .WithMessage("Status must be one of the valid options."); 

         
        RuleFor(x => x.Reason)
            .NotEmpty()
            .WithMessage("Reason is required.")
            .Length(5, 500)
            .WithMessage("Reason must be between 5 and 500 characters.");

           
        RuleFor(x => x.PatientId)
            .NotEmpty()
            .WithMessage("Patient ID is required.");

    
        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("Doctor ID is required.");

        
        RuleFor(x => x.PlaceId)
            .NotEmpty()
            .WithMessage("Place ID is required.");
    }
}

public class UpdateAppointmentValidator : AbstractValidator<UpdateAppointmentDto>
{
    public UpdateAppointmentValidator()
    {
            
        RuleFor(x => x.AppointmentDate)
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Appointment date must be in the future.");

           
        RuleFor(x => x.PatientId)
            .NotEmpty()
            .WithMessage("Patient ID is required.");

        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("Doctor ID is required.");
       
        RuleFor(x => x.Place)
            .NotEmpty()
            .WithMessage("Place ID is required.");
    }
}