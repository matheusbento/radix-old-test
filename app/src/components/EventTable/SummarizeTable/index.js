import React from "react";
import {
    Container,
    CartEvents,
    CartEmpty
} from './styles'
import { Card, Alert, Table } from 'antd';

const MainTable = props => {
    const columns = [
        {
            title: 'Tag',
            dataIndex: 'tag',
            key: 'tag',
        },
        {
            title: 'Sensor Name',
            dataIndex: 'sensorName',
            key: 'sensorName',
        },
        {
            title: 'Count',
            dataIndex: 'count',
            key: 'count',
        },
    ];

    const data = props.events.map((item, index) => {
        return {
            key: item.tag+item.sensorName,
            tag: item.tag,
            sensorName: item.sensorName,
            count: item.count
        }
    });

    return (
        <Container>
            <Card style={{ width: "100%" }}>
                <CartEvents>
                    {props.events.length ?
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

export default MainTable