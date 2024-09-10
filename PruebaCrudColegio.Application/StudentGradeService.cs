﻿using Microsoft.Identity.Client;
using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

namespace PruebaCrudColegio.Application
{
    public class StudentGradeService : IStudentGradeService
    {
        private readonly IRepository<StudentGrade> _studentGradeRepository;
        private readonly IRepository<Grade> _gradeRepository;
        private readonly IRepository<Professor> _profressorRepository;

        public StudentGradeService(IRepository<StudentGrade> studentGradeRepository,
                                   IRepository<Grade> gradeRepository,
                                   IRepository<Professor> profressorRepository)
        {
            _studentGradeRepository = studentGradeRepository;
            _gradeRepository = gradeRepository;
            _profressorRepository = profressorRepository;
        }

        public async Task<IList<StudentGradeDto>> GetAllStudentGrades()
        {
            var studentGrades = await _studentGradeRepository.GetAllAsync();
            return studentGrades.Select(studentGrade =>
            {
                var grade = _gradeRepository.GetByIdAsync(studentGrade.GradeId).Result;
                var professor = _profressorRepository.GetByIdAsync(grade.ProfessorId).Result;
                return new StudentGradeDto()
                {
                    Id = studentGrade.Id,
                    GradeName = grade.Name,
                    Section = studentGrade.Section,
                    ProfessorId = professor.Id,
                    ProfessorName = professor.FirstName + " " + professor.LastName
                };
            }).ToList();
        }

        public async Task<IList<StudentGradeDto>> GetAllStudentGradesByUserId(Guid studentId)
        {
            var studentStudentGrades = await _studentGradeRepository.GetWhere(studentGrade => studentGrade.StudentId == studentId);
            return studentStudentGrades.Select(studentStudentGrade =>
            {
                var grade = _gradeRepository.GetByIdAsync(studentStudentGrade.GradeId).Result;
                var professor = _profressorRepository.GetByIdAsync(grade.ProfessorId).Result;

                return new StudentGradeDto()
                {
                    Id = studentStudentGrade.Id,
                    GradeId = grade.Id,
                    GradeName = grade.Name,
                    ProfessorId = professor.Id,
                    StudentId = studentStudentGrade.StudentId,
                    ProfessorName = professor.FirstName + " " + professor.LastName,
                    Section = studentStudentGrade.Section,
                };

            }).ToList();
        }

        public async Task<bool> UpdateStudentGrades(Guid studentId, List<StudentGrade> studentGrades)
        {
            var studentGradeStudents = await _studentGradeRepository.GetWhere(sg => sg.StudentId == studentId);

            try
            {
                foreach (var studentGrade in studentGradeStudents)
                {
                    await _studentGradeRepository.Delete(studentGrade);
                }

                foreach (var studentGrade in studentGrades)
                {
                    await _studentGradeRepository.AddAsync(new StudentGrade() { Id = Guid.NewGuid(), GradeId = studentGrade.GradeId, StudentId = studentId, Section = studentGrade.Section });
                }
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync("Error" + e.Message);
                throw;
            }
            

            return true;
        }
    }
}
