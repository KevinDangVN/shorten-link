import React from "react";
import { useDispatch } from "react-redux";
import { Formik, Field } from "formik";
import * as Yup from "yup";
import { Row, Col, message, Button, Form as AntdForm } from "antd";

import * as actionCreator from "../../store/action/index";
import localStorageService from "../../helper/localStorage/localStorageService";
import loginApi from "../../helper/axios/loginApi/loginApi";
import CreateAntField from "../../compoment/Form/CreateAntField/CreateAntField";

const LoginForm = (props) => {
  const { setRedirectToReferrer } = props;

  const dispatch = useDispatch();

  const initForm = {
    UserName: "",
    Password: "",
  };

  const validationForm = Yup.object().shape({
    UserName: Yup.string().min(1).required("This field is required!"),
    Password: Yup.string().min(1).required("This field is required!"),
  });

  const handleSubmitForm = async (values, actions) => {
    actions.setSubmitting(false);
    try {
      const response = await loginApi.postLogin(values);
      const check = { ...response };
      localStorageService.setUserData(check);
      setRedirectToReferrer(true);
      dispatch(actionCreator.authSuccess(check));
    } catch (err) {
      message.error(err.message);
    }
  };

  return (
    <Formik
      initialValues={initForm}
      validationSchema={validationForm}
      onSubmit={handleSubmitForm}
    >
      {({ handleSubmit, submitCount, values }) => {
        return (
          <AntdForm onFinish={handleSubmit}>
            <Row gutter={48}>
              <Col xs={24}>
                <Field
                  component={CreateAntField}
                  name="UserName"
                  type="text"
                  label="Username"
                  hasFeedback
                  submitCount={submitCount}
                />
              </Col>
            </Row>
            <Row gutter={48}>
              <Col xs={24}>
                <Field
                  component={CreateAntField}
                  name="Password"
                  type="password"
                  label="Password"
                  hasFeedback
                  submitCount={submitCount}
                />
              </Col>
            </Row>
            <Row justify="center" style={{ marginTop: "2rem" }}>
              <Button type="primary" htmlType="submit" className="border">
                Login
              </Button>
            </Row>
          </AntdForm>
        );
      }}
    </Formik>
  );
};

export default LoginForm;

// const handleLoginGoogle = (event) => {
//   popupTools.popup(
//     "http://localhost:5000/oisp/auth/google",
//     "Google Connect",
//     {},
//     (err, user) => {
//       if (err) {
//         console.log("Err", err);
//       } else {
//         console.log("user", user);
//         localStorageService.setUserData(user);
//         setRedirectToReferrer(true);
//         dispatch(actionCreator.authSuccess(user));
//       }
//     }
//   );
//   event.preventDefault();
//   window.open("http://localhost:5000/oisp/auth/google", "_self");
// };
