﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }
        [SecuredOperation("card.add, admin")]
        [CacheRemoveAspect("ICardService.Get")]
        [ValidationAspect(typeof(CardValidator))]
        public IResult Add(Card card)
        {
            if (CheckCardNumber(card.CardNumber))
                return new SuccessResult(Messages.CardAlreadyExists);

            _cardDal.Add(card);
            return new SuccessResult(Messages.CardAdded);
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult(Messages.CardDeleted);
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll());
        }

        public IDataResult<List<Card>> GetByCustomerId(int id)
        {
            var getByCustomerId = _cardDal.GetAll(card => card.CustomerId == id);
            return new SuccessDataResult<List<Card>>(getByCustomerId);
        }

        public IDataResult<List<Card>> GetById(int cardId)
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(c => c.CardId == cardId));
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult(Messages.CardUpdated);
        }
        public bool CheckCardNumber(string cardNumber)
        {
            var getByCardNumber = _cardDal.Get(card => card.CardNumber == cardNumber);

            if (getByCardNumber != null)
                return true;

            return false;
        }
    }
}
