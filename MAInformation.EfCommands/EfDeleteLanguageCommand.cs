using MAInformation.Application.Commands;
using MAInformation.Application.Exceptions;
using MAInformation.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfDeleteLanguageCommand : BaseEfCommand, IDeleteLanguageCommand
    {
        public EfDeleteLanguageCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var language = _context.Languages.Find(request);
            if(language == null)
            {
                throw new EntityNotFoundException("Language");
            }

            if(language.Movies.Count > 0)
            {
                throw new EntityHasRelationException("Language has movies so you can't delete it");
            }

            _context.Languages.Remove(language);
            _context.SaveChanges();
        }
    }
}
