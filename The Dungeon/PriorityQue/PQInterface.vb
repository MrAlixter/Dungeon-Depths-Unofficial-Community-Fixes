'priority queue interface
Public Interface PQInterface
    Sub add(ByVal o As Updatable, ByVal t As Integer)  'places a upatable at time "t"
    Function remove() As Updatable 'returns the updatable at the highest priority
    Function isEmpty() As Boolean 'returns true if the queue is empty
    Function getCurrentTime() As Integer 'returns priority of the event at the highest priority

End Interface

