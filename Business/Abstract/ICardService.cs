using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardService
    {
        IDataResult<List<Card>> GetAll();
        IDataResult<List<Card>> GetById(int cardId);
        IDataResult<List<Card>> GetByCustomerId(int id);
        IResult Add(Card card);
        IResult Delete(Card car);
        IResult Update(Card car);
    }
}
