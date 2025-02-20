using BusinessLogicLayer.DTOs.Doctor;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepositories;
using Shared.DTOs.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctorRepository;

        // Konstruktor
        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        // Get doctor by Id
        public async Task<DoctorDto> GetByIdAsync(Guid id)
        {
            var doctor = await doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                return null;  // Jeśli nie znaleziono lekarza, zwróć null
            }

            return new DoctorDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Specialty = doctor.Specialty,
                Hospital = doctor.Hospital
            };
        }

        // Get all doctors
        public async Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            var doctors = await doctorRepository.GetAllAsync();
            return doctors.Select(doctor => new DoctorDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Specialty = doctor.Specialty,
                Hospital = doctor.Hospital
            });
        }

        // Get doctors by specialty
        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialtyAsync(string specialty)
        {
            var doctors = await doctorRepository.GetDoctorsBySpecialtyAsync(specialty);
            return doctors.Select(doctor => new DoctorDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Specialty = doctor.Specialty,
                Hospital = doctor.Hospital
            });
        }

        // Create a new doctor
        public async Task CreateAsync(CreateDoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                Id = Guid.NewGuid(),  // Tworzymy unikalny Id
                Name = doctorDto.Name,
                Specialty = doctorDto.Specialty,
                Hospital = doctorDto.Hospital
            };

            await doctorRepository.CreateAsync(doctor);  // Używamy repozytorium do zapisu
        }

        // Update an existing doctor
        public async Task UpdateAsync(UpdateDoctorDto doctorDto)
        {
            var doctor = await doctorRepository.GetByIdAsync(doctorDto.Id);
            if (doctor == null)
            {
                throw new InvalidOperationException("Doctor not found");  // Jeśli lekarz nie istnieje, rzucamy wyjątek
            }

            doctor.Name = doctorDto.Name ?? doctor.Name;  // Jeśli dane w DTO są null, pozostawiamy obecne wartości
            doctor.Specialty = doctorDto.Specialty ?? doctor.Specialty;
            doctor.Hospital = doctorDto.Hospital ?? doctor.Hospital;

            await doctorRepository.UpdateAsync(doctor);  // Aktualizujemy lekarza w repozytorium
        }

        // Delete a doctor
        public async Task DeleteAsync(Guid id)
        {
            var doctor = await doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                throw new InvalidOperationException("Doctor not found");  // Jeśli lekarz nie istnieje, rzucamy wyjątek
            }

            await doctorRepository.DeleteAsync(id);  // Usuwamy lekarza z repozytorium
        }
    }
}
