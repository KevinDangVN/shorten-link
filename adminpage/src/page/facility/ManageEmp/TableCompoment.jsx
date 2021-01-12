import React, { useCallback, useState, useMemo } from "react";
import { Button, Table, Space, Tooltip, Popconfirm, message } from "antd";
import { DeleteOutlined, EditOutlined } from "@ant-design/icons";

import requestApi from "../../../helper/axios/facilityApi/requestApi";
import EditModal from "./EditModal";

const TableCompoment = (props) => {
  const { data, setIsRerender } = props;
  const { Column, ColumnGroup } = Table;
  const [showEditModal, setShowEditModal] = useState(false);
  const [showViewModal, setShowViewModal] = useState(false);
  const [recordItem, setRecordItem] = useState(null);

  const PAGE_SIZE = 5;

  const handleDeleteRequest = useCallback(
    async (record) => {
      try {
        await requestApi.deleteRequest(record._id);
        message.success("The information was deleted successfully.");
        setIsRerender((pre) => !pre);
      } catch (error) {
        message.error("Something went wrong.");
      }
    },
    [setIsRerender]
  );

  const handleModal = useCallback((record) => {
    if (
      record.overallStatus &&
      !!record.isDeputyHeadApproval === false &&
      !!record.isFMTeamLeadApproval === false &&
      !!record.isAdminLeadApproval === false &&
      !!record.isAccountLeadApproval === false &&
      !!record.isDirectorApproval === false
    ) {
      setRecordItem(record);
      setShowEditModal(true);
    } else {
      setRecordItem(record);
      setShowViewModal(true);
    }
  }, []);

  return useMemo(
    () => (
      <>
        {recordItem && showEditModal && (
          <EditModal
            showEditModal={showEditModal}
            setShowEditModal={setShowEditModal}
            record={recordItem}
            setIsRerender={setIsRerender}
          />
        )}
        <Table
          dataSource={data}
          bordered
          pagination={{ pageSize: PAGE_SIZE }}
          scroll={{ x: 600, y: 600 }}
        >
          <Column title="#" dataIndex="number" key="number" width="4%" />
          <Column
            title="Employee's Name"
            dataIndex="fullName"
            key="fullName"
            width="25%"
          />
          <Column
            title="userName"
            dataIndex="fullName"
            key="fullName"
            width="25%"
          />
          <Column title="Role" dataIndex="role" key="role" width="25%" />

          <Column
            title="Action"
            width="15%"
            render={(record) => (
              <Space size="middle">
                <Tooltip title="View/Edit">
                  <Button
                    type="text"
                    icon={<EditOutlined className="ant-icon icon-primary" />}
                    onClick={() => handleModal(record)}
                  />
                </Tooltip>
                <Popconfirm
                  placement="topLeft"
                  title="Bạn có muốn xoá đề xuất?"
                  onConfirm={() => handleDeleteRequest(record)}
                >
                  <Button
                    type="text"
                    icon={<DeleteOutlined className="ant-icon icon-danger" />}
                  />
                </Popconfirm>
              </Space>
            )}
          />
        </Table>
      </>
    ),
    [
      data,
      handleDeleteRequest,
      handleModal,
      showEditModal,
      recordItem,
      setIsRerender,
    ]
  );
};

export default TableCompoment;