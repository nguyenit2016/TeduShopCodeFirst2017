using NUI.Data.Infrastructure;
using NUI.Data.Repositoties;
using NUI.Model.Models;
using System;
using System.Collections.Generic;

namespace NUI.Service
{
    public interface IOrderService
    {
        bool Add(Order order, List<OrderDetail> orderDetails);

        void SaveChanges();
    }

    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IOrderDetailRepository orderDetailRepository)
        {
            this._orderRepository = orderRepository;
            this._orderDetailRepository = orderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                _orderRepository.Add(order);
                _unitOfWork.Commit();
                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = order.ID;
                    _orderDetailRepository.Add(orderDetail);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}