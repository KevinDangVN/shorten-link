import React, { useEffect, useState } from "react";
import { Formik, Field } from "formik";
import * as Yup from "yup";
import { Row, Col, message, Button, Form as AntdForm } from "antd";

import CreateAntField from "../../../compoment/Form/CreateAntField/CreateAntField";
import requestApi from "../../../helper/axios/facilityApi/requestApi";
import Modal from "antd/lib/modal/Modal";

const AddRequest = (props) => {
  const { isAddRequestOpen, setIsAddRequestOpen, setIsRerender } = props;
  const [roleArray, setRoleArray] = useState([]);

  const initForm = {
    FullName: "",
    Email: "",
    UserName: "",
    Password: "",
    RoleId: "",
  };

  const layout = {
    labelCol: { span: 8 },
    wrapperCol: { span: 16 },
  };

  const validationForm = Yup.object().shape({
    FullName: Yup.string().min(1).required("This field is required!"),
    Email: Yup.string().min(1).required("This field is required!"),
    UserName: Yup.string().min(1).required("This field is required!"),
    Password: Yup.string().min(1).required("This field is required!"),
    RoleId: Yup.string().min(1).required("This field is required!"),
  });

  useEffect(() => {
    const fetchRoleId = async () => {
      try {
        const data = await requestApi.getRoleId();
        console.log(data);
        const converted = data.map((item) => {
          return {
            key: item.id,
            value: item.roleId,
            label: item.roleName,
          };
        });
        setRoleArray(converted);
      } catch (error) {
        message.error(
          "Something went wrong! Please contact IT Support or try again",
          10
        );
      }
    };
    fetchRoleId();
  }, []);

  const handleSubmitForm = async (values, actions) => {
    console.log(values);
  };

  return (
    <Modal
      title="Create Employee"
      visible={isAddRequestOpen}
      footer={null}
      centered
      width={960}
      onCancel={() => {
        setIsAddRequestOpen(false);
      }}
      maskClosable={false}
      destroyOnClose={true}
    >
      <div className="fm-rq">
        <Formik
          initialValues={initForm}
          validationSchema={validationForm}
          onSubmit={handleSubmitForm}
          enableReinitialize={true}
        >
          {({ handleSubmit, submitCount, values }) => {
            return (
              <AntdForm
                {...layout}
                onFinish={handleSubmit}
                className="fm-rq__wrapper"
              >
                <Row gutter={[48, 16]}>
                  <Col xs={24} lg={12}>
                    <Field
                      component={CreateAntField}
                      name="UserName"
                      type="text"
                      label="Username *"
                      submitCount={submitCount}
                      hasFeedback
                    />
                  </Col>
                  <Col xs={24} lg={12}>
                    <Field
                      component={CreateAntField}
                      name="RoleId"
                      type="select"
                      label="Role *"
                      selectOptions={roleArray}
                      submitCount={submitCount}
                      hasFeedback
                      style={{ minWidth: 150 }}
                    />
                  </Col>
                </Row>
                <Row gutter={[48, 16]}>
                  <Col xs={24} lg={12}>
                    <Field
                      component={CreateAntField}
                      name="Password"
                      label="Password*"
                      type="password"
                      submitCount={submitCount}
                      hasFeedback
                    />
                  </Col>
                  <Col xs={24} lg={12}>
                    <Field
                      component={CreateAntField}
                      name="Email"
                      label="Email*"
                      type="text"
                      submitCount={submitCount}
                      hasFeedback
                    />
                  </Col>
                </Row>

                <Row justify="center" style={{ marginTop: "2rem" }}>
                  <Button type="primary" htmlType="submit" className="border">
                    Create
                  </Button>
                </Row>
              </AntdForm>
            );
          }}
        </Formik>
      </div>
    </Modal>
  );
};

export default AddRequest;
