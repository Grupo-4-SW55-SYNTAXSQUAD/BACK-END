﻿namespace peru_ventura_center.publishing.Interfaces.REST.Resources
{
    public record TallerResource(int TallerId, string Name, string Description, string Location, string Schedule, int MaxCapacity, string SecurityMeasures);
    
}