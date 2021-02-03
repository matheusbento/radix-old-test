import React, { useState, useEffect } from "react";
import {
    Container,
    Warning,
    EventsContent,
    EventsArea,
    EventsSummary
} from './styles'
import EventTable from "@components/EventTable/MainTable"
import EventTableSummarize from "@components/EventTable/SummarizeTable"
import api from "@services/Api"
import ws from "@services/Ws"
import { Alert,  Skeleton } from 'antd';

const Events = props => {
    const [events, setEvents] = useState([]);
    const [eventsSummarize, setEventsSummarize] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [isLoadingSummarize, setIsLoadingSummarize] = useState(true);

    ws.onmessage = (message) => {
        setEvents(JSON.parse(message.data));
        setIsLoading(false);
    };

    useEffect(() => {
        async function fetchData(){
            await api.get("/api/event/count").then(res => {
                const { success, data } = res.data;
                if(success){
                    setEventsSummarize(data);
                    setIsLoadingSummarize(false);
                }
            });
        }
        fetchData();
    }, [events]);

    return (
        <Container>
            <Skeleton loading={isLoading}>
                {events.length ?
                    <EventsContent>
                        <EventsArea>
                            <EventTable events={events} loading={isLoading}></EventTable>
                            <EventsSummary>Summary</EventsSummary>
                            <EventTableSummarize events={eventsSummarize} loading={isLoadingSummarize}></EventTableSummarize>
                        </EventsArea>
                    </EventsContent>
                    :
                    <Warning>
                        <Alert message="OPS! We don't have any events!" type="warning" />
                    </Warning>
                }
            </Skeleton>
        </Container >
    )
}

export default Events