import { Col, message, Row, Form as AntdForm } from "antd";
import Modal from "antd/lib/modal/Modal";
import { Formik, Field } from "formik";
import React, { useEffect, useRef, useState } from "react";
import * as Yup from "yup";

import CreateAntField from "../../../compoment/Form/CreateAntField/CreateAntField";
import requestApi from "../../../helper/axios/facilityApi/requestApi";

const EditModal = (props) => {
  const { setShowEditModal, showEditModal, record, setIsRerender } = props;

  const layout = {
    labelCol: { span: 8 },
    wrapperCol: { span: 15 },
  };

  const initForm = {
    FullName: record.fullName,
    Email: record.email,
    UserName: record.userName,
    Password: record.password,
    RoleId: record.roleId,
  };

  const [roleArray, setRoleArray] = useState([]);

  const formRef = useRef();

  const validationForm = Yup.object().shape({
    FullName: Yup.string().min(1).required("This field is required!"),
    Email: Yup.string().min(1).required("This field is required!"),
    UserName: Yup.string().min(1).required("This field is required!"),
    Password: Yup.string().min(1).required("This field is required!"),
    RoleId: Yup.string().min(1).required("This field is required!"),
  });

  const handleOk = async (ref) => {
    console.log(ref.current.values);
    try {
      const response = await requestApi.editEmp(record.id, ref.current.values);
      console.log(response);
      setIsRerender((pre) => !pre);
      setShowEditModal(false);
    } catch (error) {
      console.log(error);
      message.error(error.response.data, 5);
    }
  };

  const handleCancel = (e) => {
    setShowEditModal(false);
  };

  useEffect(() => {
    const getRoleNameById = async () => {
      const data = await requestApi.getRoleId();
      console.log(data);
      const converted = data.map((item) => {
        return {
          key: item.id,
          value: item.id,
          label: item.roleName,
        };
      });
      setRoleArray(converted);
    };

    getRoleNameById();
  }, [record]);

  return (
    <Modal
      title="Sửa thông tin đề xuất"
      visible={showEditModal}
      onOk={() => handleOk(formRef)}
      onCancel={handleCancel}
      width={960}
      maskClosable={false}
      destroyOnClose
      centered
      className="fm-edit"
    >
      <Formik
        initialValues={initForm}
        validationSchema={validationForm}
        innerRef={formRef}
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
              <Row gutter={[48, 16]}>
                <Col xs={24} lg={12}>
                  <Field
                    component={CreateAntField}
                    name="FullName"
                    label="Full Name*"
                    type="text"
                    submitCount={submitCount}
                    hasFeedback
                  />
                </Col>
              </Row>
            </AntdForm>
          );
        }}
      </Formik>
    </Modal>
  );
};

export default EditModal;
