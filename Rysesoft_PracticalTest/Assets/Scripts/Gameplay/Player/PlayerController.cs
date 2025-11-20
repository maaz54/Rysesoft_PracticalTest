using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] float moveSpeed = 5f;
        [SerializeField] float gravity = -9.81f;
        [SerializeField] float jumpHeight = 1.5f;

        [Header("Mouse Look Settings")]
        [SerializeField] Transform cameraTransform;
        [SerializeField] float mouseSensitivity = 100f;
        [SerializeField] float xRotation = 0f;
        [SerializeField] float cameraLimit = 0f;
        [SerializeField] private bool cursorUnlocked = false;

        private CharacterController controller;
        private Vector3 velocity;
        private bool isGrounded;



        void Start()
        {
            controller = GetComponent<CharacterController>();
            // Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            HandleCursorToggle();
            if (!cursorUnlocked)
            {
                HandleMovement();
                HandleMouseLook();
                HandlePickup();
            }
        }

        private void HandleCursorToggle()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorUnlocked = !cursorUnlocked;

                if (cursorUnlocked)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }


        private void HandleMovement()
        {
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0)
                velocity.y = -2f;

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * moveSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        private void HandleMouseLook()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -cameraLimit, cameraLimit);

            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        private void HandlePickup()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Simple pickup check
                Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
                if (Physics.Raycast(ray, out RaycastHit hit, 2f))
                {
                    if (hit.collider.CompareTag("CraftedItem"))
                    {
                        // InventoryManager inv = FindObjectOfType<InventoryManager>();
                        // if (inv != null)
                        //     inv.AddToPlayerInventory(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
