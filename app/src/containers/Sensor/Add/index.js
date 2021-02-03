import React from "react";
import {
    Container
} from './styles'
import api from "@services/Api"
import { Form, Input, Button, notification } from 'antd';
import { NOTIFICATION_TYPE_SUCCESS, NOTIFICATION_TYPE_ERROR } from "@utils/constants"

const EventsAdd = props => {

    const onFinish = async values => {
        await api.post("/api/sensor", values).then(res => {
            const { success, message } = res.data;
            if (success) {
                notification[NOTIFICATION_TYPE_SUCCESS]({
                    message: 'Sensor Created',
                    description:
                        `Sensor ${values.country}.${values.region}.${values.name} was added with success`,
                });
            } else {
                notification[NOTIFICATION_TYPE_ERROR]({
                    message: 'Sensor Not Created',
                    description: message
                });
            }
        });
    };

    const onFinishFailed = errorInfo => {
        console.log('Failed:', errorInfo.errorFields);
        notification[NOTIFICATION_TYPE_ERROR]({
            message: 'Sensor Created',
            description:
                `Sensor was added with success`,
        });
    };

    return (
        <Container>
            <Form
                name="basic"
                initialValues={{ remember: true }}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
            >
                <Form.Item
                    label="Country"
                    name="country"
                    rules={[{ required: true, message: 'Please fill Country!' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Region"
                    name="region"
                    rules={[{ required: true, message: 'Please fill Region!' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Sensor Name"
                    name="name"
                    rules={[{ required: true, message: 'Please fill Sensor Name!' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item>
                    <Button type="primary" htmlType="submit">
                        Submit
                        </Button>
                </Form.Item>
            </Form>
        </Container >
    )
}

export default EventsAdd