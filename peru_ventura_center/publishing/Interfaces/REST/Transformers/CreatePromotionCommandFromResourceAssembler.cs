﻿using peru_ventura_center.publishing.Domain.Model.Commands;
using peru_ventura_center.publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.publishing.Interfaces.REST.Transformers
{
    public static class CreatePromotionCommandFromResourceAssembler
    {
        public static CreatePromotionCommand ToCommandFromResource(CreatePromotionResource resource)
        {
            return new CreatePromotionCommand(
                resource.DestinationTripId,
                resource.Name,
                resource.Description,
                resource.Offer
                );
        }
    }
}
