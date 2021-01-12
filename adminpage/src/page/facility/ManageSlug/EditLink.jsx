import React, { useRef } from "react";
import Modal from "antd/lib/modal/Modal";
import * as Yup from "yup";
import { Formik, Field } from "formik";
import { Col, message, Row, Form as AntForm, Button } from "antd";
import CreateAntField from "../../../compoment/Form/CreateAntField/CreateAntField";
import manageRequest from "../../../helper/axios/facilityApi/manageApi";

const EditLink = (props) => {
  const { isEditModalOpen, setIsEditModalOpen, setIsRerender, record } = props;
  const formRef = useRef();

  const initForm = {
    FullLink: record.fullLink,
    ShortLink: record.shortLink,
  };

  const layout = {
    labelCol: { span: 8 },
    wrapperCol: { span: 15 },
  };

  const validationForm = Yup.object().shape({
    FullLink: Yup.string().min(1).required("This field is required!"),
    ShortLink: Yup.string().min(1).required("This field is required!"),
  });

  const handleClose = () => {
    setIsEditModalOpen(false);
  };

  const handleOk = async (ref) => {
    console.log(ref.current.values);
    try {
      const response = await manageRequest.updateLink(
        record.id,
        ref.current.values
      );
      console.log(response);
      setIsRerender((pre) => !pre);
      setIsEditModalOpen(false);
    } catch (error) {
      console.log(error);
      message.error(error.response.data, 5);
    }
  };

  return (
    <Modal
      title="Create Slug"
      visible={isEditModalOpen}
      onOk={() => {
        handleOk(formRef);
      }}
      okText="Save change"
      onCancel={handleClose}
      maskClosable={false}
      destroyOnClose
      centered
      className="fm-edit"
    >
      <Formik
        initialValues={initForm}
        validationSchema={validationForm}
        innerRef={formRef}
        enableReinitialize
      >
        {({ handleSubmit, submitCount, values }) => {
          return (
            <AntForm onFinish={handleSubmit} {...layout}>
              <Row gutter={[48, 16]}>
                <Col xs={24}>
                  <Field
                    component={CreateAntField}
                    name="FullLink"
                    type="text"
                    label="Full Link"
                    submitCount={submitCount}
                    hasFeedback
                  />
                </Col>
              </Row>
              <Row gutter={[48, 16]}>
                <Col xs={24}>
                  <Field
                    component={CreateAntField}
                    name="ShortLink"
                    type="text"
                    label="Slug"
                    submitCount={submitCount}
                    hasFeedback
                  />
                </Col>
              </Row>
            </AntForm>
          );
        }}
      </Formik>
    </Modal>
  );
};

export default EditLink;
