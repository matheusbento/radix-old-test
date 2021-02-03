import React, { useState, useEffect } from "react";
import {
    Container,
    Warning,
    SensorContent,
    SensorArea
} from './styles'
import SensorAreaTable from "@components/SensorAreaTable"
import api from "@services/Api"
import { Alert,  Skeleton } from 'antd';

const SensorList = props => {
    const [sensors, setSensors] = useState([]);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        async function fetchData() {
            await api.get("/api/sensor").then(res => {
                setSensors(res.data.data);
                setIsLoading(false);
            });
        }
        fetchData();
    }, []);

    return (
        <Container>
            <Skeleton loading={isLoading}>
                {sensors.length ?
                    <SensorContent>
                        <SensorArea>
                            <SensorAreaTable sensors={sensors}></SensorAreaTable>
                        </SensorArea>
                    </SensorContent>
                    :
                    <Warning>
                        <Alert message="OPS! We don't have any sensors!" type="warning" />
                    </Warning>
                }
            </Skeleton>
        </Container >
    )
}

export default SensorList