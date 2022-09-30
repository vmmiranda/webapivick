
using System;
using System.Collections.Generic;

namespace WebVickViagensTurismoAPI.Models
{
    public class EstudanteRepositorio : IEstudanteRepositorio
    {
        private List<Estudante> estudantes = new List<Estudante>();
        private int _nextId = 1;
        public EstudanteRepositorio()
        {
            Add(new Estudante { nome = "Macoratti", id = 1, genero = "Masculino", idade = 55 });
            Add(new Estudante { nome = "Jefferson", id = 2, genero = "Masculino", idade = 24 });
            Add(new Estudante { nome = "Miriam", id = 3, genero = "Feminino", idade = 35 });
            Add(new Estudante { nome = "Janice", id = 4, genero = "Feminino", idade = 21 });
            Add(new Estudante { nome = "Jessica", id = 5, genero = "Feminino", idade = 25 });
        }
        public IEnumerable<Estudante> GetAll()
        {
            return estudantes;
        }
        public Estudante Get(int id)
        {
            return estudantes.Find(s => s.id == id);
        }
        public bool Add(Estudante estudante)
        {
            bool addResult = false;
            if (estudante == null)
            {
                return addResult;
            }
            int index = estudantes.FindIndex(s => s.id == estudante.id);
            if (index == -1)
            {
                estudantes.Add(estudante);
                addResult = true;
                return addResult;
            }
            else
            {
                return addResult;
            }
        }

        public void Remove(int id)
        {
            estudantes.RemoveAll(s => s.id == id);
        }
        public bool Update(Estudante estudante)
        {
            if (estudante == null)
            {
                throw new ArgumentNullException("estudante");
            }
            int index = estudantes.FindIndex(s => s.id == estudante.id);
            if (index == -1)
            {
                return false;
            }
            estudantes.RemoveAt(index);
            estudantes.Add(estudante);
            return true;
        }
    }
}