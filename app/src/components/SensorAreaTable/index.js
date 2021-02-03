import React from "react";
import {
    Container,
    CartEvents,
    CartEmpty
} from './styles'
import { Card, Alert, Table } from 'antd';

const SensorAreaTable = props => {
    const columns = [
        {
            title: 'Country',
            dataIndex: 'country',
            key: 'country',
        },
        {
            title: 'Region',
            dataIndex: 'region',
            key: 'region',
        },
        {
            title: 'Sensor Name',
            dataIndex: 'name',
            key: 'name',
        },
    ];

    const data = props.sensors.map((item, index) => {
        return {
            key: item.id,
            country: item.country,
            region: item.region,
            name: item.name
        }
    });

    return (
        <Container>
            <Card style={{ width: "100%" }}>
                <CartEvents>
                    {props.sensors.length ?
                        <>
                            <Table columns={columns} dataSource={data} size="small" />
                        </>
                        : (
                            <CartEmpty>
                                <Alert message="OPS! Your table is empty" type="warning" />
                            </CartEmpty>
                        )
                    }
                </CartEvents>
            </Card>
        </Container>
    )
}

export default SensorAreaTable